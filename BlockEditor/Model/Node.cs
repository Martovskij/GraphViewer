using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SampleCode.Model
{
  public class Node<T> : INotifyPropertyChanged where T : class
  {
    private Node<T> parent;

    private List<Node<T>> childNodes = new List<Node<T>>();

    public T Payload { get; set; }

    public IEnumerable<Node<T>> ChildNodes
    {
      get
      {
        return this.childNodes;
      }
    }

    public Node(Node<T> parent)
    {
      this.parent = parent;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      var handler = this.PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
