#region License
/*
MIT License
Copyright �2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

#region Original Credits/License
/*
Copyright (c) 2002-2004 Marcus Geelnard

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would
   be appreciated but is not required.

2. Altered source versions must be plainly marked as such, and must not
   be misrepresented as being the original software.

3. This notice may not be removed or altered from any source
   distribution.

Marcus Geelnard
marcus.geelnard at home.se
*/
#endregion Original Credits/License

using System;
using Tao.Glfw;
using Tao.OpenGl;

namespace GlfwExamples {
    #region Class Documentation
    /// <summary>
    ///     This is a small test application for GLFW.
    /// </summary>
    /// <remarks>
    ///     The program lists all available fullscreen video modes.
    /// </remarks>
    #endregion Class Documentation
    public sealed class ListModes {
        // --- Fields ---
        #region Private Constants
        // Maximum number of modes that we want to list
        private const int MAX_NUMBER_OF_MODES = 400;
        #endregion Private Constants

        // --- Application Entry Point ---
        #region Main(string[] args)
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {
            Glfw.GLFWvidmode desktopMode;
            Glfw.GLFWvidmode[] availableModes = new Glfw.GLFWvidmode[MAX_NUMBER_OF_MODES];
            int modeCount;

            // Initialize GLFW
            if(Glfw.glfwInit() == Gl.GL_FALSE) {
                return;
            }

            // Show desktop video mode
            Glfw.glfwGetDesktopMode(out desktopMode);
            Console.WriteLine("Desktop mode: {0} x {1} x {2}", desktopMode.Width,
                desktopMode.Height, desktopMode.RedBits + desktopMode.GreenBits +
                desktopMode.BlueBits);

            // List available video modes
            modeCount = Glfw.glfwGetVideoModes(availableModes, MAX_NUMBER_OF_MODES);
            Console.WriteLine("Available modes:");
            for(int i = 0; i < modeCount; i++) {
                Console.WriteLine("{0}: {1} x {2} x {3}", i, availableModes[i].Width,
                    availableModes[i].Height, availableModes[i].RedBits +
                    availableModes[i].GreenBits + availableModes[i].BlueBits);
            }

            // Terminate GLFW
            Glfw.glfwTerminate();

            Console.Write("\n\nPress Enter to exit...");
            Console.ReadLine();
        }
        #endregion Main(string[] args)
    }
}
