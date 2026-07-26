using PE18_JSON_Charakterverwaltung.Models;

namespace PE18_JSON_Charakterverwaltung.Services;

public class CharakterService
{
    public List<Charakter> ImportiereJson(string pfad)
    {
        throw new NotImplementedException();
    }

    public void ExportiereJson(
        string pfad,
        List<Charakter> charaktere)
    {
        throw new NotImplementedException();
    }

    public void ZeigeCharaktere(
        List<Charakter> charaktere)
    {
        throw new NotImplementedException();
    }

    public Charakter? FindeCharakterNachId(
        List<Charakter> charaktere,
        int id)
    {
        throw new NotImplementedException();
    }

    public Gegenstand? FindeGegenstandNachId(
        Charakter charakter,
        int gegenstandId)
    {
        throw new NotImplementedException();
    }
}
