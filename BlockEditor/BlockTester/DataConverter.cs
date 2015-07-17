using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCode;

namespace BlockTester
{
  public class DataConverter : IEntityHierarchyConverter
  {
    public object Convert(BlockEditor editor, object data)
    { 
      throw new NotImplementedException();
    }

    public object ConvertBack(object data)
    {
      throw new NotImplementedException();
    }
  }
}
