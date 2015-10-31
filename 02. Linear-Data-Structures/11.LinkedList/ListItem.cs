namespace _11.LinkedList
{
    public class ListItem<T>
    {
        private T value;

        public ListItem(T inputValue)
        {
            this.value = inputValue;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem { get; set; }
    }
}
