﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkModel;
using Utils;
using System.Windows;
using SampleCode.Model;

namespace SampleCode
{
  /// <summary>
  /// The view-model for the main window.
  /// </summary>
  public class BlockEditorViewModel : AbstractModelBase
  {

    #region Internal Data Members

    /// <summary>
    /// This is the network that is displayed in the window.
    /// It is the main part of the view-model.
    /// </summary>
    public NetworkViewModel network = null;

    #endregion Internal Data Members

    public BlockEditorViewModel()
    {
      // Add some test data to the view-model.
      PopulateWithTestData();
    }

    /// <summary>
    /// This is the network that is displayed in the window.
    /// It is the main part of the view-model.
    /// </summary>
    public NetworkViewModel Network
    {
      get
      {
        return network;
      }
      set
      {
        network = value;

        OnPropertyChanged("Network");
      }
    }

    private int verticalOffset = 80;

    private int prevPosition = 0;

    public void BuildGraph(Node root)
    {
      if (!root.ChildNodes.Any())
        return;

      this.prevPosition = this.prevPosition + this.verticalOffset;
      var rootBlock = this.CreateNode(root.Payload.ToString(), new Point(10, 10));
      foreach (var childNode in root.ChildNodes)
      {
        var childBlock = this.CreateNode(childNode.Payload.ToString(), new Point(10, prevPosition));
        var connection = new ConnectionViewModel
        {
          SourceConnector = rootBlock.Connectors[2],
          DestConnector = childBlock.Connectors[0]
        };
        this.Network.Connections.Add(connection);
      }
      foreach (var child in root.ChildNodes)
        this.BuildGraph(child);
    }

    /// <summary>
    /// Called when the user has started to drag out a connector, thus creating a new connection.
    /// </summary>
    public ConnectionViewModel ConnectionDragStarted(ConnectorViewModel draggedOutConnector, Point curDragPoint)
    {
      if (draggedOutConnector.AttachedConnections.Any())
      {
        //
        // There is an existing connection attached to the connector that has been dragged out.
        // Remove the existing connection from the view-model.
        //
        this.Network.Connections.RemoveRange(draggedOutConnector.AttachedConnections as IEnumerable);
      }

      //
      // Create a new connection to add to the view-model.
      //
      var connection = new ConnectionViewModel();

      //
      // Link the source connector to the connector that was dragged out.
      //
      connection.SourceConnector = draggedOutConnector;

      //
      // Set the position of destination connector to the current position of the mouse cursor.
      //
      connection.DestConnectorHotspot = curDragPoint;

      //
      // Add the new connection to the view-model.
      //
      this.Network.Connections.Add(connection);

      return connection;
    }

    /// <summary>
    /// Called as the user continues to drag the connection.
    /// </summary>
    public void ConnectionDragging(ConnectionViewModel connection, Point curDragPoint)
    {
      //
      // Update the destination connection hotspot while the user is dragging the connection.
      //
      connection.DestConnectorHotspot = curDragPoint;
    }

    /// <summary>
    /// Called when the user has finished dragging out the new connection.
    /// </summary>
    public void ConnectionDragCompleted(ConnectionViewModel newConnection, ConnectorViewModel connectorDraggedOut, ConnectorViewModel connectorDraggedOver)
    {
      if (connectorDraggedOver == null)
      {
        //
        // The connection was unsuccessful.
        // Maybe the user dragged it out and dropped it in empty space.
        //
        this.Network.Connections.Remove(newConnection);
        return;
      }

      //
      // The user has dragged the connection on top of another valid connector.
      //

      var existingConnections = connectorDraggedOver.AttachedConnections;
      if (existingConnections != null)
      {
        //
        // There is already a connection attached to the connector that was dragged over.
        // Remove the existing connection from the view-model.
        //
        this.Network.Connections.RemoveRange(existingConnections as IEnumerable);
      }

      //
      // Finalize the connection by attaching it to the connector
      // that the user dropped the connection on.
      //
      newConnection.DestConnector = connectorDraggedOver;
    }

    /// <summary>
    /// Delete the currently selected nodes from the view-model.
    /// </summary>
    public void DeleteSelectedNodes()
    {
      // Take a copy of the nodes list so we can delete nodes while iterating.
      var nodesCopy = this.Network.Nodes.ToArray();

      foreach (var node in nodesCopy)
      {
        if (node.IsSelected)
        {
          DeleteNode(node);
        }
      }
    }

    /// <summary>
    /// Delete the node from the view-model.
    /// Also deletes any connections to or from the node.
    /// </summary>
    public void DeleteNode(Block node)
    {
      //
      // Remove all connections attached to the node.
      //
      this.Network.Connections.RemoveRange(node.AttachedConnections);

      //
      // Remove the node from the network.
      //
      this.Network.Nodes.Remove(node);
    }

    /// <summary>
    /// Create a node and add it to the view-model.
    /// </summary>
    public Block CreateNode(string name, Point nodeLocation)
    {
      var node = new Block(name);
      node.X = nodeLocation.X;
      node.Y = nodeLocation.Y;

      //
      // Create the default set of four connectors.
      //
      node.Connectors.Add(new ConnectorViewModel());
      node.Connectors.Add(new ConnectorViewModel());
      node.Connectors.Add(new ConnectorViewModel());
      node.Connectors.Add(new ConnectorViewModel());

      //
      // Add the new node to the view-model.
      //
      this.Network.Nodes.Add(node);

      return node;
    }

    #region Private Methods

    /// <summary>
    /// A function to conveniently populate the view-model with test data.
    /// </summary>
    private void PopulateWithTestData()
    {
      //
      // Create a network, the root of the view-model.
      //
      this.Network = new NetworkViewModel();

      //            //
      //            // Create some nodes and add them to the view-model.
      //            //
      //            var node1 = CreateNode("Node1", new Point(10, 10));
      //            var node2 = CreateNode("Node2", new Point(200, 10));
      //
      //            //
      //            // Create a connection between the nodes.
      //            //
      //            var connection = new ConnectionViewModel();
      //            connection.SourceConnector = node1.Connectors[1];
      //            connection.DestConnector = node2.Connectors[3];
      //
      //            //
      //            // Add the connection to the view-model.
      //            //
      //            this.Network.Connections.Add(connection);
    }

    #endregion Private Methods
  }
}
