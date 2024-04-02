namespace Pizzaria
{
    public abstract class Profile
    {
        //Instance Field
        private string _surname;
        private string _lastname;
        private int _age;
        private int _cpr;

        //Constuctor
        public Profile(int cpr, string surname, string lastname, int age)
        {
            _cpr = cpr;
            _surname = surname;
            _lastname = lastname;
            _age = age;
        }

        //Properties
        public int CPR { get => _cpr; set => _cpr = value; }
        public string Surname { get => _surname; }
        public string Lastname { get => _lastname; }
        public int Age { get => _age; }
    }
}
