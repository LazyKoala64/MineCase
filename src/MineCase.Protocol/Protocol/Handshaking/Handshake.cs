﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MineCase.Serialization;

namespace MineCase.Protocol.Handshaking
{
    [Packet(0x00)]
    [GenerateSerializer(Methods = GenerateSerializerMethods.Both)]
    public sealed partial class Handshake : ISerializablePacket
    {
        [SerializeAs(DataType.VarInt)]
        public uint ProtocolVersion;

        [SerializeAs(DataType.String)]
        public string ServerAddress;

        [SerializeAs(DataType.UnsignedShort)]
        public ushort ServerPort;

        [SerializeAs(DataType.VarInt)]
        public uint NextState;

        public static Handshake Deserialize(ref SpanReader br)
        {
            return new Handshake
            {
                ProtocolVersion = br.ReadAsVarInt(out _),
                ServerAddress = br.ReadAsString(),
                ServerPort = br.ReadAsUnsignedShort(),
                NextState = br.ReadAsVarInt(out _)
            };
        }
    }
}
