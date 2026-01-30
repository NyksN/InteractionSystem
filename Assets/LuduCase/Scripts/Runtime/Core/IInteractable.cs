using UnityEngine;

namespace LuduCase.Runtime.Core
{
    /// <summary>
    /// Etkileþim türlerini belirleyen enum.
    /// </summary>
    public enum InteractionType
    {
        Instant,
        Hold,
        Toggle
    }

    /// <summary>
    /// Oyuncunun etkileþime geçebileceði nesneler için temel arayüz.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Nesnenin etkileþim türünü döndürür.
        /// </summary>
        InteractionType InteractionType { get; }

        /// <summary>
        /// UI üzerinde gösterilecek etkileþim metni (Örn: "Press E to Open").
        /// </summary>
        string InteractionPrompt { get; }

        /// <summary>
        /// Nesne ile etkileþime geçildiðinde çaðrýlýr.
        /// </summary>
        /// <param name="interactor">Etkileþimi baþlatan obje (genellikle oyuncu olacak).</param>
        void Interact(GameObject interactor);

        /// <summary>
        /// Nesnenin þu anda etkileþime uygun olup olmadýðýný kontrol eder.
        /// </summary>
        /// <param name="interactor">Kontrol eden obje.</param>
        /// <returns>Etkileþim mümkünse true.</returns>
        bool CanInteract(GameObject interactor);
    }
}