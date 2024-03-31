namespace Pizzaria
{
    public abstract class Profile
    {
        //Instance Field
        private string _surname;
        private string _lastname;
        private int _age;
        private int _id;

        //Constuctor
        public Profile(string surname, string lastname, int age)
        {
            _surname = surname;
            _lastname = lastname;
            _age = age;
        }

        //Properties
        public string Surname { get => _surname; }
        public string Lastname { get => _lastname; }
        public int Age { get => _age; }
        public int ID { get => _id; set => _id = value; }
    }
}
