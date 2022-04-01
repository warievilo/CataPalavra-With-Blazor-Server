using CataPalavra.Buscador.Interfaces;

namespace CataPalavra.BlazorServer.Data;

public class CataPalavraService
{
    private readonly IBuscadorService _buscadorService;
    public CataPalavraService(IBuscadorService buscadorService)
    {
        _buscadorService = buscadorService;
    }

    public List<List<string>> Buscar(string mascara, string letrasIgnoradas, string letrasObrigatorias)
    {
        var resultadoDaBusca = _buscadorService.Buscar(mascara, letrasIgnoradas, letrasObrigatorias);

        var palavras = resultadoDaBusca.ToList();
        
        var retorno = new List<List<string>>(); 

        int tamanho = 6;

        for (int i = 0; i < palavras.Count; i += tamanho) 
            retorno.Add(palavras.GetRange(i, Math.Min(tamanho, palavras.Count - i))); 

        return retorno;
    }
}