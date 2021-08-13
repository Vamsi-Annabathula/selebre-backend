using System;
using System.Collections.Generic;
using System.Text;

namespace Selebre.Core.Celebration
{
    public interface ICelebrationService
    {
        public bool IsCelebrationTodayForUser(int id);
    }
}
