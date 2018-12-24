﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.IO;
using osu.Framework.Audio.Track;
using osu.Framework.IO.Stores;

namespace osu.Framework.iOS.Audio
{
    public class IOSTrackManager : TrackManager
    {
        public IOSTrackManager(IResourceStore<byte[]> store) : base(store)
        {
        }

        public override Track CreateTrack(Stream data, bool quick) => new IOSTrackBass(data, quick);
    }
}
