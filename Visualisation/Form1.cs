using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualisation
{

    public partial class FormVisualisation : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        public FormVisualisation()
        {
            InitializeComponent();
        }

        private void FormVisualisation_Load(object sender, EventArgs e)
        {

        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if (comboBoxSorting.Text == "Выберите алгоритм сортировки") MessageBox.Show("Не выбран алгоритм сортировки!");
            else if(textBoxAmount.Text == "") MessageBox.Show("Не введено число элементов!");
            else
            {
                #region Ициализация
                stopwatch.Reset();
                labelInfo.Text = "Операция: инициализация...";
                labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                panelFrame.Controls.Clear();
                int count = 0, temp, size = panelFrame.Size.Height,
                amount = Convert.ToInt32(textBoxAmount.Text),
                maxHeight = panelFrame.Height / amount, maxWidht = panelFrame.Width / amount,
                delay = Convert.ToInt32(numericUpDownDelay.Value);
                string sortingMethod = comboBoxSorting.Text;
                ProgressBar[] progressBars = new ProgressBar[amount]; 
                Random rand = new Random();
                if(amount > 500) MessageBox.Show("Введно слишком большое число элементов!\nЧисло элементов не должно превышать 500.");
                else
                {
                    for (int i = 0; i < progressBars.Length; i++)
                    {
                        progressBars[i] = new ProgressBar();
                        progressBars[i].Size = new Size(1, size -= maxHeight);
                        progressBars[i].Location = new Point(count += maxWidht, panelFrame.Height - progressBars[i].Height);
                        progressBars[i].Cursor = Cursors.Hand;
                        panelFrame.Controls.Add(progressBars[i]);

                    }
                    for (int i = progressBars.Length - 1; i >= 1; i--)
                    {
                        int j = rand.Next(i + 1);
                        temp = progressBars[j].Height;
                        progressBars[j].Size = new Size(1, progressBars[i].Height);
                        progressBars[i].Size = new Size(1, temp);
                        progressBars[j].Location = new Point(progressBars[j].Location.X, panelFrame.Height - progressBars[j].Height);
                        progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                        await Task.Delay(1);
                    }
                    #endregion
                    #region Алгоритмы сортировки
                    switch (sortingMethod)
                    {
                        case "Bubble sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            bool isSorted = false;
                            while (!isSorted)
                            {
                                for (int i = 0; i < progressBars.Length; i++)
                                {
                                    for (int j = 0; j < progressBars.Length - 1; j++)
                                    {
                                        if (progressBars[j].Size.Height > progressBars[j + 1].Size.Height)
                                        {
                                            temp = progressBars[j].Size.Height;
                                            progressBars[j].Size = new Size(1, progressBars[j + 1].Size.Height);
                                            progressBars[j + 1].Size = new Size(1, temp);
                                            progressBars[j].Location = new Point(progressBars[j].Location.X, panelFrame.Height - progressBars[j].Height);
                                            progressBars[j + 1].Location = new Point(progressBars[j + 1].Location.X, panelFrame.Height - progressBars[j + 1].Height);
                                            labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                            labelCurrentArray.Text = $"Текущий массив: x = {progressBars[j].Location.X}; значение = {progressBars[j].Height}";
                                            labelNextArray.Text = $"Cледующий массив: x = {progressBars[j + 1].Location.X}; значение = {progressBars[j + 1].Height}";
                                            await Task.Delay(delay);
                                        }
                                        else isSorted = true;
                                    }
                                }
                            }
                            stopwatch.Stop();
                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Heap sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            int N = progressBars.Length;
                            for (int i = N / 2 - 1; i >= 0; i--)
                            {
                                Heapify(N, i);
                                labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                await Task.Delay(delay);
                            }
                            for (int i = N - 1; i > 0; i--)
                            {
                                temp = progressBars[0].Height;
                                progressBars[0].Size = new Size(1, progressBars[i].Height);
                                progressBars[i].Size = new Size(1, temp);
                                progressBars[0].Location = new Point(progressBars[0].Location.X, panelFrame.Height - progressBars[0].Height);
                                progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                Heapify(i, 0);
                                labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                labelCurrentArray.Text = $"Текущий массив: x = {progressBars[0].Location.X}; значение = {progressBars[0].Height}";
                                labelNextArray.Text = $"Cледующий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                await Task.Delay(delay);
                            }
                            async void Heapify(int _N, int i)
                            {
                                int largest = i;
                                int l = 2 * i + 1;
                                int r = 2 * i + 2;

                                if (l < _N && progressBars[l].Height > progressBars[largest].Height)
                                    largest = l;

                                if (r < _N && progressBars[r].Height > progressBars[largest].Height)
                                    largest = r;

                                if (largest != i)
                                {
                                    temp = progressBars[i].Height;
                                    progressBars[i].Size = new Size(1, progressBars[largest].Height);
                                    progressBars[largest].Size = new Size(1, temp);
                                    progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                    progressBars[largest].Location = new Point(progressBars[largest].Location.X, panelFrame.Height - progressBars[largest].Height);
                                    Heapify(_N, largest);
                                    labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                    labelCurrentArray.Text = $"Текущий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                    labelNextArray.Text = $"Cледующий массив: x = {progressBars[largest].Location.X}; значение = {progressBars[largest].Height}";
                                    await Task.Delay(delay);
                                }
                            }
                            stopwatch.Stop();
                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Selection sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            int n = progressBars.Length;
                            for (int i = 0; i < n - 1; i++)
                            {
                                int min_idx = i;
                                for (int j = i + 1; j < n; j++)
                                    if (progressBars[j].Height < progressBars[min_idx].Height)
                                        min_idx = j;

                                temp = progressBars[min_idx].Height;
                                progressBars[min_idx].Size = new Size(1, progressBars[i].Height);
                                progressBars[i].Size = new Size(1, temp);
                                progressBars[min_idx].Location = new Point(progressBars[min_idx].Location.X, panelFrame.Height - progressBars[min_idx].Height);
                                progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                labelCurrentArray.Text = $"Текущий массив: x = {progressBars[min_idx].Location.X}; значение = {progressBars[min_idx].Height}";
                                labelNextArray.Text = $"Cледующий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                await Task.Delay(delay);
                            }
                            stopwatch.Stop();
                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Shell sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            n = progressBars.Length;
                            for (int g = n / 2; g > 0; g /= 2)
                            {
                                for (int i = g; i < n; i += 1)
                                {
                                    temp = progressBars[i].Height;
                                    int j;
                                    for (j = i; j >= g && progressBars[j - g].Height > temp; j -= g)
                                    {
                                        progressBars[j].Size = new Size(1, progressBars[j - g].Height);
                                        progressBars[j].Location = new Point(progressBars[j].Location.X, panelFrame.Height - progressBars[j].Height);
                                        labelNextArray.Text = $"Cледующий массив: x = {progressBars[j - 1].Location.X}; значение = {progressBars[j - 1].Height}";
                                    }
                                    progressBars[j].Size = new Size(1, temp);
                                    progressBars[j].Location = new Point(progressBars[j].Location.X, panelFrame.Height - progressBars[j].Height);
                                    labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                    labelCurrentArray.Text = $"Текущий массив: x = {progressBars[j + 1].Location.X}; значение = {progressBars[j + 1].Height}";
                                    await Task.Delay(delay);
                                }
                            }
                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Quick sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            SortArray(progressBars, 0, progressBars.Length - 1);
                            async void SortArray(ProgressBar[] array, int leftIndex, int rightIndex)
                            {
                                var i1 = leftIndex;
                                var j1 = rightIndex;
                                var pivot = progressBars[leftIndex].Height;
                                while (i1 <= j1)
                                {
                                    while (progressBars[i1].Height < pivot)
                                    {
                                        progressBars[i1].Location = new Point(progressBars[i1].Location.X, panelFrame.Height - progressBars[i1].Height);
                                        i1++;
                                    }

                                    while (progressBars[j1].Height > pivot)
                                    {
                                        progressBars[j1].Location = new Point(progressBars[j1].Location.X, panelFrame.Height - progressBars[j1].Height);
                                        j1--;
                                    }
                                    if (i1 <= j1)
                                    {
                                        temp = progressBars[i1].Height;
                                        progressBars[i1].Size = new Size(1, progressBars[j1].Height);
                                        progressBars[j1].Size = new Size(1, temp);
                                        progressBars[i1].Location = new Point(progressBars[i1].Location.X, panelFrame.Height - progressBars[i1].Height);
                                        progressBars[j1].Location = new Point(progressBars[j1].Location.X, panelFrame.Height - progressBars[j1].Height);
                                        labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                        labelCurrentArray.Text = $"Текущий массив: x = {progressBars[i1].Location.X}; значение = {progressBars[i1].Height}";
                                        labelNextArray.Text = $"Cледующий массив: x = {progressBars[j1].Location.X}; значение = {progressBars[j1].Height}";
                                        await Task.Delay(delay);
                                        i1++;
                                        j1--;
                                    }
                                }
                                if (leftIndex < j1)
                                    SortArray(array, leftIndex, j1);
                                if (i1 < rightIndex)
                                    SortArray(array, i1, rightIndex);
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Comb sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            int gap = progressBars.Length;
                            bool swapped = false;
                            while (gap != 1 || swapped == true)
                            {
                                gap = getNextGap(gap);
                                swapped = false;
                                for (int i = 0; i < progressBars.Length - gap; i++)
                                {
                                    if (progressBars[i].Height > progressBars[i + gap].Height)
                                    {
                                        temp = progressBars[i].Height;
                                        progressBars[i].Size = new Size(1, progressBars[i + gap].Height);
                                        progressBars[i + gap].Size = new Size(1, temp);
                                        progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                        progressBars[i + gap].Location = new Point(progressBars[i + gap].Location.X, panelFrame.Height - progressBars[i + gap].Height);
                                        labelCurrentArray.Text = $"Текущий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                        labelNextArray.Text = $"Cледующий массив: x = {progressBars[i + gap].Location.X}; значение = {progressBars[i + gap].Height}";
                                        swapped = true;
                                        labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                        await Task.Delay(delay);
                                    }
                                }
                            }
                            int getNextGap(int _gap)
                            {
                                _gap = (_gap * 10) / 13;

                                if (_gap < 1)
                                    return 1;
                                return _gap;
                            }
                            stopwatch.Stop();
                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Insertion sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            for (int i = 1; i < progressBars.Length; i++)
                            {
                                int k = progressBars[i].Height;
                                int j = i - 1;

                                while (j >= 0 && progressBars[j].Height > k)
                                {
                                    progressBars[j + 1].Size = new Size(1, progressBars[j].Height);
                                    progressBars[j].Size = new Size(1, k);
                                    progressBars[j + 1].Location = new Point(progressBars[j + 1].Location.X, panelFrame.Height - progressBars[j + 1].Height);
                                    progressBars[j].Location = new Point(progressBars[j].Location.X, panelFrame.Height - progressBars[j].Height);
                                    labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                    labelCurrentArray.Text = $"Текущий массив: x = {progressBars[j + 1].Location.X}; значение = {progressBars[j + 1].Height}";
                                    labelNextArray.Text = $"Cледующий массив: x = {progressBars[j].Location.X}; значение = {progressBars[j].Height}";
                                    await Task.Delay(delay);
                                    j--;
                                }
                            }
                            stopwatch.Stop();

                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                        case "Shaker sort":
                            stopwatch.Restart();
                            labelTime.Text = "Время: ";
                            labelInfo.Text = "Операция: сортировка...";
                            count = progressBars.Length;
                            int left = 0, right = count - 1;
                            int flag = 1;
                            while ((left < right) && flag > 0)
                            {
                                flag = 0;
                                for (int i = left; i < right; i++)
                                {
                                    if (progressBars[i].Height > progressBars[i + 1].Height)
                                    {
                                        temp = progressBars[i].Height;
                                        progressBars[i].Size = new Size(1, progressBars[i + 1].Height);
                                        progressBars[i + 1].Size = new Size(1, temp);
                                        progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                        progressBars[i + 1].Location = new Point(progressBars[i + 1].Location.X, panelFrame.Height - progressBars[i + 1].Height);
                                        flag = 1;
                                        labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                        labelCurrentArray.Text = $"Текущий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                        labelNextArray.Text = $"Cледующий массив: x = {progressBars[i + 1].Location.X}; значение = {progressBars[i + 1].Height}";
                                        await Task.Delay(delay);
                                    }
                                }
                                right--;
                                for (int i = right; i > left; i--)
                                {
                                    if (progressBars[i - 1].Height > progressBars[i].Height)
                                    {
                                        temp = progressBars[i].Height;
                                        progressBars[i].Size = new Size(1, progressBars[i - 1].Height);
                                        progressBars[i - 1].Size = new Size(1, temp);
                                        progressBars[i].Location = new Point(progressBars[i].Location.X, panelFrame.Height - progressBars[i].Height);
                                        progressBars[i - 1].Location = new Point(progressBars[i - 1].Location.X, panelFrame.Height - progressBars[i - 1].Height);
                                        flag = 1;
                                        labelTime.Text = "Время: " + stopwatch.Elapsed.ToString();
                                        labelCurrentArray.Text = $"Текущий массив: x = {progressBars[i].Location.X}; значение = {progressBars[i].Height}";
                                        labelNextArray.Text = $"Cледующий массив: x = {progressBars[i - 1].Location.X}; значение = {progressBars[i - 1].Height}";
                                        await Task.Delay(delay);
                                    }
                                }
                                left++;
                            }
                            stopwatch.Stop();

                            for (int i = 0; i < progressBars.Length; i++)
                            {
                                progressBars[i].Step = 1;
                                progressBars[i].Maximum = progressBars[i].Height;
                                progressBars[i].Value = progressBars[i].Maximum;
                                progressBars[i].Style = ProgressBarStyle.Blocks;
                            }
                            labelInfo.Text = "Ожидание...";
                            break;
                    }
                    #endregion
                }

            }
        }
        private void textBoxAmount_Click(object sender, EventArgs e)
        {
            textBoxAmount.Clear();
        }
    }
}
