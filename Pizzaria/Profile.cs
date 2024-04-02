namespace Pizzaria
{
    public abstract class Profile
    {
        //Instance Field
        private string _firstname;
        private string _lastname;
        private int _age;
        private int _cpr;

        //Constuctor
        public Profile(int cpr, string firstname, string lastname, int age)
        {
            _cpr = cpr;
            _firstname = firstname;
            _lastname = lastname;
            _age = age;
        }

        //Properties
        public int CPR { get => _cpr; set => _cpr = value; }
        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
