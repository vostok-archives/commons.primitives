using System;
using Vostok.Commons.Primitives.Parsers;

namespace Vostok.Commons.Primitives
{
    [Serializable]
    public struct DataRate : IEquatable<DataRate>, IComparable<DataRate>
    {
        public static DataRate FromBytesPerSecond(long bytes) => 
            new DataRate(bytes);

        public static DataRate FromKilobytesPerSecond(double kilobytes) => 
            new DataRate((long)(kilobytes * DataSizeConstants.Kilobyte));

        public static DataRate FromMegabytesPerSecond(double megabytes) => 
            new DataRate((long)(megabytes * DataSizeConstants.Megabyte));

        public static DataRate FromGigabytesPerSecond(double gigabytes) => 
            new DataRate((long)(gigabytes * DataSizeConstants.Gigabyte));

        public static DataRate FromTerabytesPerSecond(double terabytes) => 
            new DataRate((long)(terabytes * DataSizeConstants.Terabyte));

        public static DataRate FromPetabytesPerSecond(double petabytes) => 
            new DataRate((long)(petabytes * DataSizeConstants.Petabyte));

        public static bool TryParse(string input, out DataRate result) => 
            DataRateParser.TryParse(input, out result);

        public static DataRate Parse(string input) => 
            DataRateParser.Parse(input);

        private readonly long bytesPerSecond;

        public DataRate(long bytesPerSecond) => 
            this.bytesPerSecond = bytesPerSecond;

        public long BytesPerSecond => bytesPerSecond;

        public double KilobytesPerSecond => bytesPerSecond / (double)DataSizeConstants.Kilobyte;

        public double MegabytesPerSecond => bytesPerSecond / (double)DataSizeConstants.Megabyte;

        public double GigabytesPerSecond => bytesPerSecond / (double)DataSizeConstants.Gigabyte;

        public double TerabytesPerSecond => bytesPerSecond / (double)DataSizeConstants.Terabyte;

        public double PetabytesPerSecond => bytesPerSecond / (double)DataSizeConstants.Petabyte;

        public string ToString(bool shortFormat = true)
        {
            if (PetabytesPerSecond >= 1)    return $"{PetabytesPerSecond:0.####} {(shortFormat ? "PB/sec" : "petabytes/second")}";
            if (TerabytesPerSecond >= 1)    return $"{TerabytesPerSecond:0.####} {(shortFormat ? "TB/sec" : "terabytes/second")}";
            if (GigabytesPerSecond >= 1)    return $"{GigabytesPerSecond:0.####} {(shortFormat ? "GB/sec" : "gigabytes/second")}";
            if (MegabytesPerSecond >= 1)    return $"{MegabytesPerSecond:0.####} {(shortFormat ? "MB/sec" : "megabytes/second")}";
            if (KilobytesPerSecond >= 1)    return $"{KilobytesPerSecond:0.####} {(shortFormat ? "KB/sec" : "kilobytes/second")}";

            return $"{bytesPerSecond} {(shortFormat ? "B/sec" : "bytes/second")}";
        }

        public static DataRate operator +(DataRate speed1, DataRate speed2) => 
            new DataRate(speed1.bytesPerSecond + speed2.bytesPerSecond);

        public static DataRate operator -(DataRate speed1, DataRate speed2) => 
            new DataRate(speed1.bytesPerSecond - speed2.bytesPerSecond);

        public static DataRate operator *(DataRate speed, int multiplier) => 
            new DataRate(speed.bytesPerSecond * multiplier);

        public static DataRate operator *(DataRate speed, long multiplier) => 
            new DataRate(speed.bytesPerSecond * multiplier);

        public static DataRate operator *(DataRate speed, double multiplier) =>
            new DataRate((long)(speed.bytesPerSecond * multiplier));

        public static DataSize operator *(DataRate speed, TimeSpan time) =>
            new DataSize((long)(speed.bytesPerSecond * time.TotalSeconds));

        public static DataSize operator *(TimeSpan time, DataRate speed) =>
            new DataSize((long)(speed.bytesPerSecond * time.TotalSeconds));

        public static DataRate operator /(DataRate speed, int divider) => 
            new DataRate(speed.bytesPerSecond / divider);

        public static DataRate operator /(DataRate speed, long divider) => 
            new DataRate(speed.bytesPerSecond / divider);

        public static DataRate operator /(DataRate speed, double divider) => 
            new DataRate((long)(speed.bytesPerSecond / divider));

        public bool Equals(DataRate other) => 
            bytesPerSecond == other.bytesPerSecond;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is DataRate speed && Equals(speed);
        }

        public override int GetHashCode() => 
            bytesPerSecond.GetHashCode();

        public static bool operator ==(DataRate left, DataRate right) => 
            left.Equals(right);

        public static bool operator !=(DataRate left, DataRate right) => 
            !left.Equals(right);

        public int CompareTo(DataRate other) => 
            bytesPerSecond.CompareTo(other.bytesPerSecond);
    }
}