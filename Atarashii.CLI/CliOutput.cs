using System;
using System.IO;
using Atarashii.CLI.Resources;
using Atarashii.Common;

namespace Atarashii.CLI
{
    /// <inheritdoc />
    /// <summary>
    ///     Type dealing with writing inbound messages to the console.
    /// </summary>
    public class CliOutput : Output
    {
        /// <inheritdoc />
        /// <summary>
        ///     Decorates the inbound message and writes it to the stdout/stderr.
        /// </summary>
        public override void Write(Type type, string subject, string message)
        {
            var code = CodeFactory.Get(type);

            // write code
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  [ ");
            Console.ForegroundColor = code.Colour;
            Console.Write(code.Value);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");

            // write subject
            Console.Write("| ");
            Console.Write(subject);
            Console.Write("\t| ");

            // write message
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        /// <summary>
        ///     Outputs the banner to the CLI.
        /// </summary>
        public void WriteBanner()
        {
            void WriteFromResource(Resource resource)
            {
                Console.WriteLine(string.Empty);

                using (var reader = new StringReader(resource.Text))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) Console.WriteLine("  " + line);
                }

                Console.WriteLine(string.Empty);
            }

            void ShowAsciiBanner()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                WriteFromResource(ResourceFactory.Get(ResourceFactory.Type.Banner));
                Console.WriteLine(string.Empty);
            }

            void ShowProductName()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Program    : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("  " + Assembly.ProductName);
            }

            void ShowCompanyName()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Developers : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("  " + Assembly.CompanyName);
            }

            void ShowGitRevision()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Revision   : ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("  " + ResourceFactory.Get(ResourceFactory.Type.Revision).Text);
            }

            void ShowProgramHelp()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  Usage: .\\Atarashii.CLI.exe <commands> <args>");
                Console.WriteLine("    e.g. .\\Atarashii.CLI.exe loader load 'C:\\HCE.EXE'");

                Console.ForegroundColor = ConsoleColor.Gray;
                WriteFromResource(ResourceFactory.Get(ResourceFactory.Type.Usage));
            }

            ShowAsciiBanner();
            ShowProductName();
            ShowCompanyName();
            ShowGitRevision();
            ShowProgramHelp();
        }

        /// <summary>
        ///     Factory for building Code objects.
        /// </summary>
        private static class CodeFactory
        {
            /// <summary>
            ///     Returns a Code object based on the inbound Type.
            /// </summary>
            /// <param name="type">
            ///     Output type. <see cref="Type" />
            /// </param>
            /// <returns>
            ///     Code instance whose properties are determined by the inbound type.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">
            ///     Invalid Type enum value.
            /// </exception>
            public static Code Get(Type type)
            {
                switch (type)
                {
                    case Type.Success:
                        return new Code(" OK ", ConsoleColor.Green);
                    case Type.Info:
                        return new Code("INFO", ConsoleColor.Cyan);
                    case Type.Warn:
                        return new Code("WARN", ConsoleColor.Yellow);
                    case Type.Error:
                        return new Code("HALT", ConsoleColor.Red);
                    case Type.Dump:
                        return new Code("DUMP", ConsoleColor.Magenta);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }

        /// <summary>
        ///     Represents a decorative output code.
        /// </summary>
        private class Code
        {
            /// <summary>
            /// </summary>
            /// <param name="value">
            ///     <see cref="Value" />
            /// </param>
            /// <param name="colour">
            ///     <see cref="Colour" />
            /// </param>
            public Code(string value, ConsoleColor colour)
            {
                Value = value;
                Colour = colour;
            }

            /// <summary>
            ///     Code value.
            ///     <example>
            ///         OK, INFO, HALT
            ///     </example>
            /// </summary>
            public string Value { get; }

            /// <summary>
            ///     Colour of the code in the console.
            /// </summary>
            public ConsoleColor Colour { get; }
        }
    }
}