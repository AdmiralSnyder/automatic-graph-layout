﻿using System.Windows;
using Microsoft.Msagl.Drawing;

namespace Microsoft.Msagl.WpfGraphControl {
    public partial class AutomaticGraphLayoutControl {
        GraphViewer _graphViewer;
        public AutomaticGraphLayoutControl() {
            InitializeComponent();
            Loaded += (s, e) => SetGraph();
        }
        public Graph Graph {
            get => (Graph)GetValue(GraphProperty);
            set => SetValue(GraphProperty, value);
        }
        public static readonly DependencyProperty GraphProperty =
            DependencyProperty.Register("Graph", typeof(Graph), typeof(AutomaticGraphLayoutControl), new PropertyMetadata(default(Graph),
                (d,e)=> ((AutomaticGraphLayoutControl)d)?.SetGraph()));
     
        private void SetGraph() {
            if (Graph == null)
            {
                dockPanel.Children.Clear();
            }
            else 
            {
                if (_graphViewer == null) {
                    _graphViewer = new GraphViewer();
                }
                if (dockPanel.Children.Count == 0)
                {
                    _graphViewer.BindToPanel(dockPanel);
                }
            }
            if (_graphViewer != null)
            {
                _graphViewer.Graph = Graph;
            }
        }
    }
}