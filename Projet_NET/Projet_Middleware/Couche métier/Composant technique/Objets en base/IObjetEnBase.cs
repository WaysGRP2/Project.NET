﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    abstract class IObjetEnBase
    {
        private int id;

        public void SaveInBase(){}
        public void DeleteFromBase(){}
    }
}
