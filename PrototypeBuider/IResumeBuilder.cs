using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBuilder
{
    public interface IResumeBuilder
    {
        IResumeBuilder BuildBasicInfo(Action<BasicInfo> buildBasicInfoDelegate);
        IResumeBuilder BuildWorkExperience(Action<WorkExperience> buildWorkExperienceDelegate);
        ResumeBase Build();
    }
}
