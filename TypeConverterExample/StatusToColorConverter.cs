using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;

namespace TypeConverterExample
{
    public class StatusToColorConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }


        // 실제로 변환을 수행하는 메서드
        public override object ConvertFrom(
            ITypeDescriptorContext context,  // 변환 컨텍스트 정보 (대부분 null)
            CultureInfo culture,              // 문화권 정보 (한국어/영어 등)
            object value)                     // 실제 변환할 값
        {
            // value가 string 타입인지 확인하고, 맞으면 status 변수에 할당
            if (value is string status)
            {
                // switch 표현식 사용 (C# 8.0+)
                var color =  status.ToLower() switch
                {
                    "online" => Colors.Green,   // "online" → 초록색
                    "offline" => Colors.Red,     // "offline" → 빨간색
                    "warning" => Colors.Orange,  // "warning" → 주황색
                    _ => Colors.Gray     // 그 외 모든 것 → 회색
                };
                return new SolidColorBrush(color);
            }

            // value가 string이 아니면 부모 클래스의 기본 동작 수행
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == typeof(string) && value is Color color)
            {
                if (color == Colors.Green) return "Online";
                if (color == Colors.Red) return "Offline";
                if (color == Colors.Orange) return "Warning";
                return "Unknown";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}