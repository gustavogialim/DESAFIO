using System;

namespace PhascoalottoDesafio.Dominio.Base
{
    public abstract class Entity
    {
        Int32 _Id;

        /// <summary>
        /// Get or set the persisten object identifier
        /// </summary>
        public virtual Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }
}
