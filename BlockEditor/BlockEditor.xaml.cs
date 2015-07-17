using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetworkUI;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using Utils;
using NetworkModel;
using System.Collections;

namespace SampleCode
{
  /// <summary>
  /// This is a Window that uses NetworkView to display a flow-chart.
  /// </summary>
  public partial class BlockEditor : UserControl
  {
    public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(
      "DataSource", typeof(object), typeof(BlockEditor), new PropertyMetadata(default(object)));

    public object DataSource
    {
      get { return (object)this.GetValue(DataSourceProperty); }
      set { SetValue(DataSourceProperty, value); }
    }

    public static readonly DependencyProperty HiearchyConverterProperty = DependencyProperty.Register(
      "HiearchyConverter", typeof(IEntityHierarchyConverter), typeof(BlockEditor), new PropertyMetadata(default(IEntityHierarchyConverter)));

    public IEntityHierarchyConverter HiearchyConverter
    {
      get { return (IEntityHierarchyConverter)GetValue(HiearchyConverterProperty); }
      set { SetValue(HiearchyConverterProperty, value); }
    }


     
    public BlockEditor()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Convenient accessor for the view-model.
    /// </summary>
    private BlockEditorViewModel ViewModel
    {
      get
      {
        return (BlockEditorViewModel)this.DataContext;
      }
    }

    /// <summary>
    /// Event raised when the Window has loaded.
    /// </summary>
    private void LoadedHandler(object sender, RoutedEventArgs e)
    {

    }

    /// <summary>
    /// Event raised when the user has started to drag out a connection.
    /// </summary>
    private void networkControl_ConnectionDragStarted(object sender, ConnectionDragStartedEventArgs e)
    {
      var draggedOutConnector = (ConnectorViewModel)e.ConnectorDraggedOut;
      var curDragPoint = Mouse.GetPosition(this.networkControl);

      //
      // Delegate the real work to the view model.
      //
      var connection = this.ViewModel.ConnectionDragStarted(draggedOutConnector, curDragPoint);

      //
      // Must return the view-model object that represents the connection via the event args.
      // This is so that NetworkView can keep track of the object while it is being dragged.
      //
      e.Connection = connection;
    }

    /// <summary>
    /// Event raised while the user is dragging a connection.
    /// </summary>
    private void networkControl_ConnectionDragging(object sender, ConnectionDraggingEventArgs e)
    {
      var curDragPoint = Mouse.GetPosition(this.networkControl);
      var connection = (ConnectionViewModel)e.Connection;
      this.ViewModel.ConnectionDragging(connection, curDragPoint);
    }

    /// <summary>
    /// Event raised when the user has finished dragging out a connection.
    /// </summary>
    private void networkControl_ConnectionDragCompleted(object sender, ConnectionDragCompletedEventArgs e)
    {
      var connectorDraggedOut = (ConnectorViewModel)e.ConnectorDraggedOut;
      var connectorDraggedOver = (ConnectorViewModel)e.ConnectorDraggedOver;
      var newConnection = (ConnectionViewModel)e.Connection;
      this.ViewModel.ConnectionDragCompleted(newConnection, connectorDraggedOut, connectorDraggedOver);
    }

    /// <summary>
    /// Event raised to delete the selected node.
    /// </summary>
    private void DeleteSelectedNodes_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      this.ViewModel.DeleteSelectedNodes();
    }

    /// <summary>
    /// Event raised to create a new node.
    /// </summary>
    private void CreateNode_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      Point newNodeLocation = Mouse.GetPosition(this.networkControl);
      this.ViewModel.CreateNode("New Node!", newNodeLocation);
    }
  }
}
