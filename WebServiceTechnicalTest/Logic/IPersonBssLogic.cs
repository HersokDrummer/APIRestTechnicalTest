using System.Collections.Generic;

namespace WebServiceTechnicalTest.Logic
{
    public interface IPersonBssLogic
    {
        int AddPerson(PersonModel person);
        int UpdatePerson(PersonModel person);
        int DeletePerson(int id);        
        List<PersonModel> GetAllPersonModels();
    }
}