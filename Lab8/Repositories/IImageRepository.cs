using Lab8.DataObjects;

namespace Lab8.Repositories
{
    public interface IImageRepository
    {
        public List<ImageObject> GetImages();
        public byte[] GetImageData(int id);
        public void SaveImage(ImageObject image);
    }
}
