   M S B A M L   `   `   `  ����R  NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics  5      G CSimpleSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NetworkUI	NetworkUI 5      'clr-namespace:ZoomAndPan
ZoomAndPan 5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"   ZoomAndPan.ZoomAndPanControl  �� 
TargetType �� Property �� Value �� 
TargetType ��Name   selectionBorderColor �� Color " selectionBorderBackgroundColor �� Opacity  NetworkUI.NodeItem �� RelativeSource �� AncestorType  NetworkUI.NetworkView	 �� Path
 �� Mode ��Name �� CornerRadius �� Padding �� Triggers P� Property P� Value �� 
TargetName  NetworkUI.ConnectorItem  noScrollViewerListBoxStyle K� IsItemsHost  NetworkUI.NodeItemsControl  Name   NodeItemContainerStyle   NodeItemTemplate   NodeItemTemplateSelector   Nodes �� SelectionMode ��Name#   ConnectionItemContainerStyle   ConnectionItemTemplate%   ConnectionItemTemplateSelector   Connections ��Name J� Opacity�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml     5      Ediagnostics5clr-namespace:System.Diagnostics;assembly=WindowsBase  5      !localclr-namespace:NetworkUI  5      '
zoomAndPanclr-namespace:ZoomAndPan  5      %9
  '         &	      &	 %    '  [    7   7  '  4    &	 m    '  �    7  �� 5      "    6
   .�5
      ��  � �� 5      �� 5   
   "   6   .R�5      �� #��z��6   #��z��5      #��z��5      ._�5      �� $ PART_Content��6   $
��Left=�5      $	��Top=�5      5       5"      5%      5'      �� 5)      $
 Blue��61   �� 5+      $
 0.25Q�5,      $
 Blue��5-      �� 50      "   6
   .�53      ��  �@ ParentNetworkView 6*   ��  �� *FindAncestor+"  $	 .��� 56       �@��Left 6$   �� *X+ �� *Self+$
 TwoWay=��� 57       �@��Top 6#   �� *Y+ �� *Self+$
 TwoWay=��� 5:       �@K�ZIndex 6&   �� *ZIndex+ �� *Self+$
 TwoWay=��� 5=       � ��
 ���� 6#   �� 5>       � ��
 ���� 6$   �� 5?       � ��$ 1q�6(   �� 5B       � �� 5C      �� 5D   
   "  6   .R�5E      � .+�5M      �� $ selectionBorder��6   #��z��5N      #��z��5O      #��z��5P      #��z��5Q      $ 2��5R      # z��5S      ._�5V      �� 5X      5Z       5[      P� 5]       �@��
IsSelected . . �5`      �� $ selectionBorder��6   8    � ��6K   5a      P� 5c       �@��
IsSelected . . �5f      �� $ selectionBorder��6   8   � ��6J   5g      5i      5k      5l      �� 5o      "   6
   .�5r      ��  �@ ParentNetworkView 6*   ��  �� *FindAncestor+"  $	 .��� 5u       �@ ParentNodeItem 6'   ��  �� *FindAncestor+"  $	 .��� 5x       � �� 5y      �� 5z   
   "  6   .R�5}      �� 5      5�      5�      �� 5�      "  ��6-   .�5�      ��  � �� 5�      �� 5�   
   " ��6   .R�5�      ��  . 6   5�      5�      5�      �� 5�      "   6
   .�5�      ��  � �� 5�      �� 5�   
   "  6   .R�5�      �� #��z��6   #��z��5�      #��z��5�      ._�5�      � .+�5�        $ PART_NodeItemsControl��6'   #��z 5�   '   #��z 5�   '   #��z 5�   '   #��z 5�   '   $ Extended=�5�   '   8��  5�   '   �� 5�      $! PART_ConnectionItemsControl��6   #��z 5�      #��z 5�      #��z 5�      #��z 5�      ��5�      �� 5�      .R�5�      �� 5�      5�      �� 5�      $ PART_DragSelectionCanvas��6   $y�	Collapsed=�69   .+�5�      �� $ PART_DragSelectionBorder��6   
����ح�
����  �$��1q�5�      $ 1��5�      $	 0.5Q�5�      5�      5�      5�      5�      5�      5�      5�      