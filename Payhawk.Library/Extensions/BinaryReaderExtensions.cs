namespace Without.Systems.Payhawk.Extensions;

public static class BinaryReaderExtensions
{
    public static int ReadInt32BigEndian(this BinaryReader reader)
    {
        byte[] bytes = reader.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToInt32(bytes, 0);
    }
}