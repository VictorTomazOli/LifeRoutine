namespace LifeRoutine.Domain.ValueObjects;

public class Perimetria
{
    protected Perimetria() { }
    /*public Perimetria(float ombro, float torax, float cintura, float abdome, float quadril,
        float braco_esquerdo, float braco_direito, float antebraco_direito, float antebraco_esquerdo,
        float coxa_direito, float coxa_esquerda, float panturrilha_direita, float panturrilha_esquerda
        )
    {
        Ombro = ombro;
        Torax = torax;
        Cintura = cintura;
        Abdome = abdome;
        Quadril = quadril;
        Braço_Direito = braco_direito;
        Braço_Esquerdo = braco_esquerdo;
        AnteBraço_Direito = antebraco_direito;
        AnteBraço_Esquerdo = antebraco_esquerdo;
        Coxa_Direita = coxa_direito;
        Coxa_Esquerda = coxa_direito;
        Panturrilha_Direita = panturrilha_direita;
        Panturrilha_Esquerda = panturrilha_esquerda;
    }*/
    public float Ombro { get; set; }
    public float Torax { get; set; }
    public float Cintura { get; set; }
    public float Abdome { get; set; }
    public float Quadril { get; set; }
    public float Braço_Direito { get; set; }
    public float Braço_Esquerdo { get; set; }
    public float AnteBraço_Direito { get; set; }
    public float AnteBraço_Esquerdo { get; set; }
    public float Coxa_Direita { get; set; }
    public float Coxa_Esquerda { get; set; }
    public float Panturrilha_Direita { get; set; }
    public float Panturrilha_Esquerda { get; set; }
}