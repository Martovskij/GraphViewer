   M S B A M L   `   `   `  ����G  CSimpleSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NetworkModelNetworkModel  5      %clr-namespace:NetworkUI	NetworkUI  5      R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5      'clr-namespace:SampleCode
SampleCode  5      +clr-namespace:NetworkModelNetworkModel  5      %clr-namespace:NetworkUI	NetworkUI  5	          SampleCode.BlockEditor   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      1NetworkModelclr-namespace:NetworkModel    5      +	NetworkUIclr-namespace:NetworkUI    5      Kdiagnostics5clr-namespace:System.Diagnostics;assembly=WindowsBase    5      (localclr-namespace:SampleCode    5      1networkModelclr-namespace:NetworkModel    5      +	networkUiclr-namespace:NetworkUI    5	      -   5          >�Name$  
mainWindow��5
      $	��800��5      $	��500��5       +� FocusedElement 5      ��  �� ElementName$ networkControl�� � 	Resources 5          Commands.DeleteSelectedNodes  Commands.CreateNode �� DataType&    NetworkModel.ConnectionViewModel   SampleCode.Arrow J� IsHitTestVisible
   End   Start   NetworkUI.NodeItem �� 
TargetType	 �� Property
 �� Value   NetworkUI.ConnectorItem �� Mode �� 
TargetType � Cursor �� RadiusX �� RadiusY   NetworkModel.Block � ColumnDefinitions � RowDefinitions � DataContext��%�  &	        &	      (�� &     5$      *, +)'  �     '  �    (�� �    5h      *, +)�� 5      6   �� 5      6   �� 5$      "  6   .R�5'        
���   � .  
���   �$��2��5,       5'      �� *DestConnectorHotspot+ 5*      �� *SourceConnectorHotspot+5,      59      �� 5C      "  6   .�5D      �� 		 �@ X
 6   �� *X+�� 5E      		 �@ Y
 6   �� *Y+�� 5F      	 �@��
IsSelected
 6%   �� *
IsSelected+5G      �� 5J      "  6   .�5R      �� 	 �@ Hotspot
 6"   �� *	Hotspot+$ OneWayToSource=��� 5U      	 � ��
 5V   
   �� 5W      "  6   .R�5X      �� $��12��6   $��12��5Y      $
 Hand��5Z      
�������$ 1��5\      $ 1��5]      
���   �5^      5_      5a   	   5b      �� 5h      "  6   .R�5i      � $	��120��6   $��60��6   .+�5l   
   �� 
�������$ 4��5m      $ 4��5n      
���   �5o      � 5u   
   $��-8q�6    5v      �� 5w      $
��Auto �6   �� 5x      $��* �6   $��10��6)   �� 5y      $
��Auto �6    5{      �� 5|      $
��Auto �6   �� 5}      $��* �6   �� 5~      $
��Auto �6   .+�5�      �� $��1��6   $��1��5�      $��Center=�5�      $��Center=�5�      ��5�      �� *Name+  5�      $��0��6$   $��1��5�   $    5�   $   �� *Connectors[0]+  5�      $��1��6$   $��2��5�   $    5�   $   �� *Connectors[1]+  5�      $��2��6$   $��1��5�   $    5�   $   �� *Connectors[2]+  5�      $��1��6$   $��0��5�   $    5�   $   �� *Connectors[3]+5�      5�   	   5�      5�       J� InputBindings 5�      �� 5�      
 �� Key$	 Del��6    �� Command# [  6    J� CommandBindings 5�      )  #System.Windows.Input.CommandBinding  5�      -   5           Command# [  5�      6M     5�      -   5        # [ 5�      6D    � ContextMenu 5�      �� 5�      .@�5�      m�  m� Command# [ 6   $��Create Node��5�       � ToolTip$ Creates a new node��5�      5�       5�      %   SampleCode.BlockEditorViewModel  5�      .��5�      �� |�.  $
��Auto=�6#   .��5�         NetworkUI.NetworkView  -   5          Name$ networkControl��5�      	   NetworkUI.NetworkView 	  ConnectionDragCompleted$, &networkControl_ConnectionDragCompleted��5�       	  ConnectionDragStarted$* $networkControl_ConnectionDragStarted��5�       	  ConnectionDragging$' !networkControl_ConnectionDragging��5�      $
��2000��5�      $
��2000��5�         ConnectionsSource 5�      �� *Network.Connections+    NodesSource  5�      �� *Network.Nodes+5�      5�      