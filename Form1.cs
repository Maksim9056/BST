using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private Label indexLabel;
        private TextBox indexTextBox;
        private Button insertButton;
        private ListBox heapListBox;
        private Button sortButton;
        private ListBox sortedListBox;

        private BinaryHeap binaryHeap;
        public Form1()
        {
            binaryHeap = new BinaryHeap();

            InitializeComponents();



        }
   
        //private Label indexLabel;
        //private TextBox indexTextBox;
        //private Button insertButton;
        //private ListBox heapListBox;
        //private Button sortButton;
        //private ListBox sortedListBox;






        private void InitializeComponents()
        {
            // Form settings
            this.Text = "Binary Heap Visualizer";
            this.Width = 600;
            this.Height = 400;

            // Index label
            indexLabel = new Label();
            indexLabel.Text = "Value: ";
            indexLabel.Location = new System.Drawing.Point(10, 10);
            indexLabel.AutoSize = true;

            // Index TextBox
            indexTextBox = new TextBox();
            indexTextBox.Location = new System.Drawing.Point(60, 10);
            indexTextBox.Width = 100;

            // Insert button
            insertButton = new Button();
            insertButton.Text = "Insert";
            insertButton.Location = new System.Drawing.Point(170, 10);
            insertButton.Click += InsertButton_Click;

            // Heap ListBox
            heapListBox = new ListBox();
            heapListBox.Location = new System.Drawing.Point(10, 40);
            heapListBox.Width = 200;
            heapListBox.Height = 300;

            // Sort button
            sortButton = new Button();
            sortButton.Text = "Sort";
            sortButton.Location = new System.Drawing.Point(220, 160);
            sortButton.Click += SortButton_Click;

            // Sorted ListBox
            sortedListBox = new ListBox();
            sortedListBox.Location = new System.Drawing.Point(230, 10);
            sortedListBox.Width = this.Width - 260;
            sortedListBox.Height = this.Height - 60;

            // Add controls to the form
            this.Controls.Add(indexLabel);
            this.Controls.Add(indexTextBox);
            this.Controls.Add(insertButton);
            this.Controls.Add(heapListBox);
            this.Controls.Add(sortButton);
            this.Controls.Add(sortedListBox);
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(indexTextBox.Text, out int value))
            {
                binaryHeap.Insert(value);
                UpdateHeapListBox();
            }
            indexTextBox.Text = string.Empty;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            List<int> sortedArray = binaryHeap.Sort();
            UpdateSortedListBox(sortedArray);
        }

        private void UpdateHeapListBox()
        {
            heapListBox.Items.Clear();
            foreach (int item in binaryHeap.GetHeap())
            {
                heapListBox.Items.Add(item);
            }
        }

        private void UpdateSortedListBox(List<int> sortedArray)
        {
            sortedListBox.Items.Clear();
            foreach (int item in sortedArray)
            {
                sortedListBox.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
            {

            }


        }

    

    class BinaryHeap
    {
        private List<int> heap;

        public BinaryHeap()
        {
            heap = new List<int>();
        }

        public List<int> GetHeap()
        {
            return heap;
        }

        public void Insert(int value)
        {
            heap.Add(value);
            int currentIndex = heap.Count - 1;

            while (currentIndex > 0 && heap[currentIndex] > heap[GetParentIndex(currentIndex)])
            {
                Swap(currentIndex, GetParentIndex(currentIndex));
                currentIndex = GetParentIndex(currentIndex);
            }
        }

        public List<int> Sort()
        {
            List<int> sortedArray = new List<int>();

            while (heap.Count > 0)
            {
                sortedArray.Add(heap[0]);
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                Heapify(0);
            }

            return sortedArray;
        }

        private void Heapify(int index)
        {
            int largestIndex = index;
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            if (leftChildIndex < heap.Count && heap[leftChildIndex] > heap[largestIndex])
                largestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[largestIndex])
                largestIndex = rightChildIndex;

            if (largestIndex != index)
            {
                Swap(index, largestIndex);
                Heapify(largestIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (2 * index) + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return (2 * index) + 2;
        }
    }
}

