using OnBase.Interfaces;

namespace OnBase
{
    /// <summary>
    /// Classe padrão das entidades.
    /// </summary>
    public abstract class Base : IBase
    {
        public int Id { get; set; }
    }
}
