using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface ICRUD<T>
    {
        //C
        int Create(T obj);
        //R
        T ReadOne(int ID);
        List<T> ReadAll();
        //U
        int Update(int ID);
        //D
        int Delete(int ID);
    }
}
