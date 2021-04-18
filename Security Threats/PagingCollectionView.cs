using System.Windows.Data;
using System.Collections;
using System.ComponentModel;

namespace Security_Threats
{
    public class PagingCollectionView : CollectionView
    {
        private IList innerList;
        private int itemsPerPage;

        private int currentPage = 1;

        public PagingCollectionView(IList innerList, int itemsPerPage) : base(innerList)
        {
            this.innerList = innerList;
            this.itemsPerPage = itemsPerPage;
        }

        public override int Count
        {
            get
            {
                if (innerList.Count == 0)
                {
                    return 0;
                }
                if (currentPage < PageCount)
                {
                    return itemsPerPage;
                }
                else
                {
                    var itemsLeft = innerList.Count % itemsPerPage;
                    if (0 == itemsLeft)
                    {
                        return itemsPerPage;
                    }
                    else
                    {
                        return itemsLeft;
                    }
                }
            }
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public int ItemsPerPage { get { return itemsPerPage; } }

        public int PageCount
        {
            get
            {
                return (innerList.Count + itemsPerPage - 1) / itemsPerPage;
            }
        }

        private int EndIndex
        {
            get
            {
                var end = currentPage * itemsPerPage - 1;
                return (end > innerList.Count) ? innerList.Count : end;
            }
        }

        private int StartIndex
        {
            get { return (currentPage - 1) * itemsPerPage; }
        }

        public override object GetItemAt(int index)
        {
            var offset = index % (itemsPerPage);
            return innerList[StartIndex + offset];
        }

        public void MoveToNextPage()
        {
            if (currentPage < PageCount)
            {
                CurrentPage += 1;
            }
            Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (currentPage > 1)
            {
                CurrentPage -= 1;
            }
            Refresh();
        }
    }
}

