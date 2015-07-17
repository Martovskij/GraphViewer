using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode
{
  public interface IEntityHierarchyConverter
  {
    object Convert(BlockEditor editor, object data);

    object ConvertBack(object data);
  }
}
