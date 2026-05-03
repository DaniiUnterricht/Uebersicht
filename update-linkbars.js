const fs = require("fs");
const path = require("path");

const rootDir = __dirname;
const linkbarFile = path.join(rootDir, "_Linkbar.json");

const START_MARKER = "<!-- LINKBAR:START -->";
const END_MARKER = "<!-- LINKBAR:END -->";

const ignoredFolders = new Set([
  ".git",
  "node_modules",
  "dist",
  "build",
  ".vscode"
]);

function readLinkbarConfig() {
  if (!fs.existsSync(linkbarFile)) {
    console.error("Fehler: _Linkbar.json wurde nicht gefunden.");
    process.exit(1);
  }

  return JSON.parse(fs.readFileSync(linkbarFile, "utf8"));
}

function getMarkdownFiles(dir) {
  let results = [];

  const entries = fs.readdirSync(dir, { withFileTypes: true });

  for (const entry of entries) {
    const fullPath = path.join(dir, entry.name);

    if (entry.isDirectory()) {
      if (!ignoredFolders.has(entry.name)) {
        results = results.concat(getMarkdownFiles(fullPath));
      }
    } else if (entry.isFile() && entry.name.endsWith(".md")) {
      results.push(fullPath);
    }
  }

  return results;
}

function toMarkdownLink(fromFile, targetPath, text) {
  const fromDir = path.dirname(fromFile);
  const absoluteTarget = path.join(rootDir, targetPath);

  let relativePath = path.relative(fromDir, absoluteTarget);

  // Windows \ zu Markdown /
  relativePath = relativePath.replace(/\\/g, "/");

  // Falls Datei im gleichen Ordner liegt
  if (!relativePath.startsWith(".")) {
    relativePath = "./" + relativePath;
  }

  return `[${text}](${relativePath})`;
}

function buildLinkbarForFile(filePath, links) {
  return links
    .map(link => toMarkdownLink(filePath, link.path, link.text))
    .join(" | ");
}

function updateFile(filePath, links) {
  const content = fs.readFileSync(filePath, "utf8");

  if (!content.includes(START_MARKER) || !content.includes(END_MARKER)) {
    return false;
  }

  const linkbar = buildLinkbarForFile(filePath, links);

  const newBlock = `${START_MARKER}
${linkbar}
${END_MARKER}`;

  const regex = new RegExp(
    `${START_MARKER}[\\s\\S]*?${END_MARKER}`,
    "m"
  );

  const newContent = content.replace(regex, newBlock);

  if (newContent !== content) {
    fs.writeFileSync(filePath, newContent, "utf8");
    return true;
  }

  return false;
}

function main() {
  const links = readLinkbarConfig();
  const markdownFiles = getMarkdownFiles(rootDir);

  let updatedCount = 0;

  for (const file of markdownFiles) {
    const wasUpdated = updateFile(file, links);

    if (wasUpdated) {
      updatedCount++;
      console.log("Aktualisiert:", path.relative(rootDir, file));
    }
  }

  console.log("");
  console.log(`Fertig. ${updatedCount} Markdown-Datei(en) aktualisiert.`);
}

main();