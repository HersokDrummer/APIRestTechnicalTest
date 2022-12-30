using System.Collections.Generic;
using System.Linq;

namespace WebServiceTechnicalTest.Logic
{
    public class PersonBssLogic : IPersonBssLogic
    {
        private List<PersonModel> PersonModels = new List<PersonModel>();

        public int AddPerson(PersonModel person)
        {
            person.Id = PersonModels.Count + 1;
            PersonModels.Add(person);
            return person.Id;
        }

        public List<PersonModel> GetAllPersonModels()
        {
            return PersonModels;
        }

        public int DeletePerson(int id) {
            if (id > 0) {
                var personToDelete = PersonModels.Where(p => p.Id == id).Select(p => p).FirstOrDefault();

                if (personToDelete != null)
                {
                    PersonModels.Remove(personToDelete);
                }
            }

            return id;
        }

        public int UpdatePerson(PersonModel person) {
            var indexOf = -1;

            if (person !=null) {
                if (person.Id > 0) {
                    indexOf = PersonModels.IndexOf(PersonModels.Find(p => p.Id == person.Id));
                    if (indexOf >= 0) {
                        PersonModels[indexOf] = person;
                    }
                }
            }
            return indexOf;
        }
    }
}
