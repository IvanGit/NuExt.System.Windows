﻿using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Interop;

namespace System.Windows
{
    /// <summary>
    /// The <see cref="WindowExtensions"/> class provides extension methods for the <see cref="Window"/> class,
    /// allowing easier management of window placement (position and state) including serialization to and from JSON.
    /// </summary>
    public static class WindowExtensions
    {
        private static readonly JsonSerializerOptions s_serializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            IgnoreReadOnlyProperties = true,
            WriteIndented = true,
            Converters = 
            {
                new RectangleJsonConverter()
            }
        };

        /// <summary>
        /// Retrieves the current placement (position and state) of the specified window.
        /// </summary>
        /// <param name="window">The instance of the <see cref="Window"/>.</param>
        /// <returns>An instance of <see cref="WindowPlacement"/> with the current values of the window's placement,
        /// or <c>null</c> if the operation fails.</returns>
        public static WindowPlacement? GetPlacement(this Window window)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(window);
#else
            ThrowHelper.WhenNull(window);
#endif
            return WindowPlacement.GetPlacement(new WindowInteropHelper(window).Handle);
        }

        /// <summary>
        /// Retrieves the current placement of the specified window and returns it as a JSON string.
        /// </summary>
        /// <param name="window">The instance of the <see cref="Window"/>.</param>
        /// <returns>A JSON string representing the current placement of the window, or <c>null</c> if the operation fails.</returns>
        public static string? GetPlacementAsJson(this Window window)
        {
            var windowPlacement = window.GetPlacement();
            if (windowPlacement is null)
            {
                return null;
            }
            windowPlacement.WindowStyle = window.WindowStyle;
            windowPlacement.ResizeMode = window.ResizeMode;
            string output = JsonSerializer.Serialize(windowPlacement, s_serializerOptions);
            return output;
        }

        /// <summary>
        /// Sets the placement (position and state) of the specified window according to the provided <see cref="WindowPlacement"/> instance.
        /// </summary>
        /// <param name="window">The instance of the <see cref="Window"/>.</param>
        /// <param name="windowPlacement">An instance of <see cref="WindowPlacement"/> specifying the new values for the window's placement.</param>
        /// <returns><c>true</c> if the operation is successful, otherwise <c>false</c>.</returns>
        public static bool SetPlacement(this Window window, WindowPlacement? windowPlacement)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(window);
#else
            ThrowHelper.WhenNull(window);
#endif
            if (windowPlacement is null)
            {
                return false;
            }
            if (windowPlacement.NormalPosition.IsEmpty)
            {
                return false;
            }
            window.WindowStyle = windowPlacement.WindowStyle;
            window.ResizeMode = windowPlacement.ResizeMode;
            return WindowPlacement.SetPlacement(new WindowInteropHelper(window).Handle, windowPlacement);
        }

        /// <summary>
        /// Sets the placement (position and state) of the specified window according to the provided JSON string.
        /// </summary>
        /// <param name="window">The instance of the <see cref="Window"/>.</param>
        /// <param name="json">A JSON string representing the desired placement of the window.</param>
        /// <returns><c>true</c> if the operation is successful, otherwise <c>false</c>.</returns>
        public static bool SetPlacement(this Window window, string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return false;
            }
            var windowPlacement = JsonSerializer.Deserialize<WindowPlacement>(json!, s_serializerOptions);
            return window.SetPlacement(windowPlacement);
        }
    }
}