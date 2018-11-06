using System;

namespace Backend.AuxiliaryClasses
{
    /// <summary>
    /// <see cref="Tuple"/> class that can hold three objects of <see cref="Referee"/> type.
    /// </summary>
    /// <seealso cref="System.Tuple{Backend.Referee, Backend.Referee, Backend.Referee}" />
    class ThreeReferees : Tuple<Referee, Referee, Referee>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeReferees"/> class.
        /// </summary>
        /// <param name="main">The main <see cref="Referee"/>.</param>
        /// <param name="suppRef1">The first supporting <see cref="Referee"/>.</param>
        /// <param name="suppRef2">The second supporting <see cref="Referee"/>.</param>
        public ThreeReferees(Referee main, Referee suppRef1, Referee suppRef2) : base(main, suppRef1, suppRef2) { }

        /// <summary>
        /// Gets the main <see cref="Referee"/>.
        /// </summary>
        /// <value>
        /// The main <see cref="Referee"/>.
        /// </value>
        public Referee GetMainReferee => this.Item1;
        /// <summary>
        /// Gets the first supporting <see cref="Referee"/>.
        /// </summary>
        /// <value>
        /// The first supporting <see cref="Referee"/>.
        /// </value>
        public Referee GetSupportingReferee1 => this.Item2;
        /// <summary>
        /// Gets the second supporting <see cref="Referee"/>.
        /// </summary>
        /// <value>
        /// The second supporting <see cref="Referee"/>.
        /// </value>
        public Referee GetSupportingReferee2 => this.Item3;
    }
}
