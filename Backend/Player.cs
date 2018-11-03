
namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Player"/> class.
    /// </summary>
    /// <seealso cref="Backend.Person" />
    class Player : Person
    {
        /// <summary>
        /// Gets the name of the <see cref="Player"/>.
        /// </summary>
        /// <value>
        /// The name of the <see cref="Player"/>.
        /// </value>
        public string GetName => base.name;
        /// <summary>
        /// Gets the <see cref="Player"/>'s surname.
        /// </summary>
        /// <value>
        /// The <see cref="Player"/>'s surname.
        /// </value>
        public string GetSurname => base.surname;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player() : base() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        public Player(string name, string surname) : base(name, surname) { }
    }
}
