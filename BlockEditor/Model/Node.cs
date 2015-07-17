using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SampleCode.Model
{
  public class Node : INotifyPropertyChanged
  {
    private readonly Node parent;

    public Node Parent
    {
      get { return this.parent; }
    }

    private List<Node> childNodes = new List<Node>();

    public object Payload { get; set; }

    public IEnumerable<Node> ChildNodes
    {
      get
      {
        return this.childNodes;
      }
    }

    public void AddChildNode(Node node)
    {
      this.childNodes.Add(node);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      var handler = this.PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public Node(Node parent)
    {
      this.parent = parent;
      this.Payload = "undefined";
    }
  }
}
