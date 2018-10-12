#region License
// Copyright (c) 2013 - 2018 Coding Adventures
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.IO;
using BridgeVs.Shared.Options;
using MicrosoftXml = System.Xml.Serialization;

namespace BridgeVs.Shared.Serialization
{
    public sealed class XmlSerializer : IServiceSerializer
    { 
        public IServiceSerializer Next { get; set; }
		
        public void Serialize<T>(Stream aStream, T objToSerialize)
        {
            using (MicrosoftXml.XmlSerializer xmlSerializer = new MicrosoftXml.XmlSerializer(typeof(T)))
            {
                xmlSerializer.Serialize(aStream, objToSerialize);
            }
        }

        public  byte[] Serialize<T>(T objToSerialize)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, objToSerialize);
                return stream.ToArray();
            }
        }

        public  T Deserialize<T>(Stream aStream)
        {
            using ( MicrosoftXml.XmlSerializer xmlSerializer = new MicrosoftXml.XmlSerializer xmlSerializer(typeof(T)))
            {
                return xmlSerializer.Deserialize(aStream) as T;
            }
        }

        public  T Deserialize<T>(byte[] objToDeserialize)
        {
            using (MemoryStream stream = new MemoryStream(objToDeserialize))
            {
                T t = Deserialize<T>(stream);
            }
        }

        public object Deserialize(byte[] objToDeserialize, Type type = null)
        {

			if (type == null)
				return null; //cannot deserialize with xml a not-known type
			
            using (MemoryStream stream = new MemoryStream(objToDeserialize))
			using ( MicrosoftXml.XmlSerializer xmlSerializer = new MicrosoftXml.XmlSerializer xmlSerializer(type))
            {
                return  xmlSerializer.Deserialize(stream);
            }
        }
        
        public override string ToString()
        {
            return SerializationOption.XmlSerializer.ToString();
        }
    }
}