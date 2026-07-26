using PE18_JSON_Charakterverwaltung.Models;
using PE18_JSON_Charakterverwaltung.Services;

const string IMPORT_PFAD = "Data/charaktere.json";
const string EXPORT_PFAD = "Data/charaktere_export.json";

CharakterService charakterService = new CharakterService();

List<Charakter> charaktere =
    charakterService.ImportiereJson(IMPORT_PFAD);

charakterService.ZeigeCharaktere(charaktere);

// Ab hier soll der Programmablauf laut Aufgabenstellung umgesetzt werden.
//
// Verwendete Service-Methoden:
//
// charakterService.FindeCharakterNachId(...)
// charakterService.FindeGegenstandNachId(...)
// charakterService.ExportiereJson(...)
// charakterService.ImportiereJson(...)
// charakterService.ZeigeCharaktere(...)
