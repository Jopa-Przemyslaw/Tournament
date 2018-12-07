
namespace Backend
{
    /// <summary>
    /// Representation of the Referee class.
    /// </summary>
    /// <seealso cref="Backend.Person" />
    public class Referee : Person
    {
        /// <summary>
        /// Gets the name of the <see cref="Referee"/>.
        /// </summary>
        /// <value>
        /// The name of the <see cref="Referee"/>.
        /// </value>
        public string GetName => base.name;
        /// <summary>
        /// Gets the <see cref="Referee"/>'s surname.
        /// </summary>
        /// <value>
        /// The <see cref="Referee"/>'s surname.
        /// </value>
        public string GetSurname => base.surname;

        /// <summary>
        /// Initializes a new instance of the <see cref="Referee"/> class.
        /// </summary>
        public Referee() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Referee"/> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Referee"/>.</param>
        /// <param name="surname">Thee <see cref="Referee"/>'s surname.</param>
        public Referee(string name,string surname) : base(name, surname) { }
    }
}
