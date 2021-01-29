using System;

namespace Atlas.Mvvm.ViewModels.Settings.TrackSettings
{
    public class TrackSettingsModel
    {
        public string City { get; set; }
        public string Name { get; set; }
        public int SlotsCount { get; set; }
        public double TrackLength { get; set; }
        public TimeSpan DelayAfterStopping { get; set; }
    }
}
