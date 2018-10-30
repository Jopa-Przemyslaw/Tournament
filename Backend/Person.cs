
namespace Backend
{
    /// <summary>
    /// Abstract representation of the <see cref="Person" /> class.
    /// </summary>
    abstract class Person
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="Person"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        protected string name { get; private set; }
        /// <summary>
        /// Gets or sets the surname of the <see cref="Person"/>.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        protected string surname { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        protected Person() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        protected Person(string name, string surname) { this.name = name; this.surname = surname; }
    }
}
