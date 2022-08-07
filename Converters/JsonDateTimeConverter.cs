//
//  Copyright 2022  Soluciones Modernas 10x
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dev10x.AspnetCore.Commons.Api.Converters
{
    /// <summary>
    /// Date format converter for json (des)seralization
    /// </summary>
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {

        private readonly string _dateFormat;

        /// <summary>
        /// Constructor for a specific date format
        /// </summary>
        /// <param name="dateFormat">Date format string representation</param>
        public JsonDateTimeConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        /// <summary>
        /// Constructor with default date time format (dd/MM/yyyy)
        /// </summary>
        public JsonDateTimeConverter()
        {
            _dateFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// DateTime deserialization
        /// </summary>
        /// <param name="reader">Utf8 Json Reader</param>
        /// <param name="typeToConvert">Type to convert the value</param>
        /// <param name="options">Json Serializer Options </param>
        /// <returns></returns>
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            DateTime.ParseExact(reader.GetString(),
                _dateFormat, CultureInfo.InvariantCulture);

        /// <summary>
        /// DateTime serialization
        /// </summary>
        /// <param name="writer">Utf8 Json Writer</param>
        /// <param name="value">value to be Serialized</param>
        /// <param name="options">Json Serializer Options</param>
        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(
                _dateFormat, CultureInfo.InvariantCulture));

    }
}
