namespace Models
{
    public class Role:Base.Entity
    {
        public Role():base()
        {

        }

        //******************************************************
        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false)]

        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength: 50)]

        [System.ComponentModel.DataAnnotations.Schema.Index
            (IsUnique = true)]
        public string Name { get; set; }
        //******************************************************
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof( Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        //******************************************************
        //Step 2
        public virtual System.Collections.Generic.IList<User> Users { get; set; }
    }
}
