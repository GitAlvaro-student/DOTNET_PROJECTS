namespace ScreenSound.Modelos
{
    internal interface IAvaliavel
    {
        void AdicionarNota(Avaliacao avaliacao);
        double Media { get; }
    }
}
