using RealWorlOneAPI.Models;

namespace RealWorlOneAPI.Services {
    /// <summary>
    /// Cat operations
    /// </summary>
    public interface ICat {
        /// <summary>
        /// Get upside down cat
        /// </summary>
        /// <returns></returns>
        byte[] Get();

        /// <summary>
        /// Get cat image with specific rotate
        /// </summary>
        /// <param name="rotate"></param>
        /// <returns></returns>
        byte[] GetByRotate(Rotate rotate);
    }
}
