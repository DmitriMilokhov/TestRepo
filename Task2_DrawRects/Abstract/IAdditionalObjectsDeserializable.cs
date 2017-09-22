using EmvuCV_VideoPlayer.Model;

namespace EmvuCV_VideoPlayer.Abstract
{
    interface IAdditionalObjectsDeserializable
    {
        /// <param name="path">path with name</param>
        Tracks Deserialize(string path="");
    }
}
