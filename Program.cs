using System;
using System.Text;

namespace ComputerCS
{
    class Program
    {
        class CPU
        {
            public string Model { get; set; }
        }
        class Mainboard
        {
            public string Model { get; set; }
        }
        class RAM
        {
            public string Model { get; set; }
        }
        class HDD
        {
            public string Model { get; set; }
        }
        class Videocard
        {
            public string Model { get; set; }
        }
        class Soundcard
        {
            public string Model { get; set; }
        }
        class Computer
        {
            public CPU cpu { get; set; }
            public Mainboard mainboard { get; set; }
            public RAM ram { get; set; }
            public HDD hdd { get; set; }
            public Videocard videocard { get; set; }
            public Soundcard soundcard { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (cpu != null)
                {
                    sb.Append(cpu.Model + "\n");
                }
                if (mainboard != null)
                {
                    sb.Append(mainboard.Model + "\n");
                }
                if (ram != null)
                {
                    sb.Append(ram.Model + "\n");
                }
                if (hdd != null)
                {
                    sb.Append(hdd.Model + "\n");
                }
                if (videocard != null)
                {
                    sb.Append(videocard.Model + "\n");
                }
                if (soundcard != null)
                {
                    sb.Append(soundcard.Model + "\n");
                }
                return sb.ToString();
            }
        }
        // abstract class builder
        abstract class ComputerBuilder
        {
            public Computer computer { get; private set; }
            public void build_computer()
            {
                computer = new Computer();
            }
            public abstract void set_cpu();
            public abstract void set_mainboard();
            public abstract void set_ram();
            public abstract void set_hdd();
            public abstract void set_videocard();
            public abstract void set_soundcard();

        }
        class SysAdmin
        {
            public Computer build(ComputerBuilder computerbuilder)
            {
                computerbuilder.build_computer();
                computerbuilder.set_cpu();
                computerbuilder.set_mainboard();
                computerbuilder.set_ram();
                computerbuilder.set_hdd();
                computerbuilder.set_videocard();
                computerbuilder.set_soundcard();
                return computerbuilder.computer;
            }
        }
        class PCBuilder : ComputerBuilder
        {
            public override void set_cpu()
            {
                this.computer.cpu = new CPU { Model = "Intel Core i7 8700"};
            }
            public override void set_mainboard()
            {
                this.computer.mainboard = new Mainboard { Model = "Onda P250S"};
            }
            public override void set_ram()
            {
                this.computer.ram = new RAM { Model = "HyperX DDR4"};
            }
            public override void set_hdd()
            {
                this.computer.hdd = new HDD { Model = "Original KingDian N480"};
            }
            public override void set_videocard()
            {
                this.computer.videocard = new Videocard { Model = "Yeston AMD Radeon RX570 4G"};
            }
            public override void set_soundcard()
            {
                this.computer.soundcard = new Soundcard { Model = "ASUS EssenceSTXII Sound Card"};
            }
        }
        class LaptopBuilder : ComputerBuilder
        {
            public override void set_cpu()
            {
                this.computer.cpu = new CPU { Model = "Intel® Core™ i7-8550U"};
            }
            public override void set_mainboard()
            {
                this.computer.mainboard = new Mainboard { Model = "60NB04L0-MB1021 Asus N550JK "};
            }
            public override void set_ram()
            {
                this.computer.ram = new RAM { Model = "32GB Corsair 2133MHz"};
            }
            public override void set_hdd()
            {
                this.computer.hdd = new HDD { Model = "500GB SATA HDD"};
            }
            public override void set_videocard()
            {
                this.computer.videocard = new Videocard { Model = "INTEL® HD GRAPHICS 610/620/630"};
            }
            public override void set_soundcard()
            {
                this.computer.soundcard = new Soundcard { Model = "Realtek High Definition Audio"};
            }
        }
        static void Main(string[] args)
        {
            //create SysAdmin object
            SysAdmin sysadmin = new SysAdmin();
            //create PC object
            ComputerBuilder cbuilder = new PCBuilder();
            //build new PC
            Computer pc = sysadmin.build(cbuilder);
            Console.WriteLine("Building PC \n");
            Console.WriteLine(pc.ToString());
            //build new Laptop
            cbuilder = new LaptopBuilder();
            Computer laptop = sysadmin.build(cbuilder);
            Console.WriteLine("Building Laptop \n");
            Console.WriteLine(laptop.ToString());
        }
    }
}
