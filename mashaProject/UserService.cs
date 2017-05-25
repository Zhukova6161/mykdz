using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mashaProject
{
    class UserService
    {
        UserRepository userRepository = new UserRepository();
        AbonementRepository abonementRepository = new AbonementRepository();
        public Boolean login(String username, String password)
        {

            {
                try
                {
                    User user = userRepository.getUserByUsername(username);
                    if(user.Password.Equals(password)){
                        return true;
                    }else{
                        return false;
                    }
                }
                catch (NullReferenceException ex)
                {
                    return false;
                }
                }
        }

        public void addAbonementToCustomer(Int32 idCustomer, Abonement abonement)
        {
            try
            {
                if (abonementRepository.getAbonementByCustomer(idCustomer) != null)
                {
                    throw new Exception("абонемент уже существует");
                }
            }
            catch (Exception ex)
            {
                if (!abonementRepository.addAbonement(abonement.Desc, abonement.Cost, abonement.VisitsCount, abonement.VisitsCount, idCustomer))
                {
                    throw new Exception("Невозможно добавить абонемент");
                }

            }

        }

        }
}
    

