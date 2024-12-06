using System;

namespace WarOfNovus
{
    public class NPC
    {
        private string[] tutorialSteps = new string[]
        {
            "Trainer: Welcome to War of Novus! In this game, you will embark on an epic journey.",
            "Trainer: First, you need to create your character. Choose your nation and job wisely.",
            "Trainer: You will encounter various enemies. Use your skills and strategies to defeat them.",
            "Trainer: Good luck, and may you become the hero of Novus!"
        };

        private int currentStep = 0;

        public void ShowNextTutorialStep()
        {
            if (currentStep < tutorialSteps.Length)
            {
                Console.WriteLine(tutorialSteps[currentStep]);
                currentStep++;
            }
            else
            {
                Console.WriteLine("Trainer: You have completed the tutorial. Enjoy the game!");
            }
        }

        public bool IsTutorialCompleted()
        {
            return currentStep >= tutorialSteps.Length;
        }

        public void ShowDeathMessage()
        {
            Console.WriteLine("Trainer: Your endeavor was valiant, but alas, you have fallen. Do not give up, for every defeat is a lesson. Rise again and continue your journey!");
        }
    }
}