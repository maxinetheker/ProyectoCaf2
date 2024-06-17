using UnityEngine;

public class DesactivarObjetosConPropiedad : MonoBehaviour
{
    private struct ObjetoConPosicionOriginal
    {
        public PropiedadesFlecha objeto;
        public Vector3 posicionOriginal;
    }

    private ObjetoConPosicionOriginal[] objetosConPosicionOriginal;

    void Start()
    {
        // Guardar la posición original de todos los objetos con PropiedadesFlecha
        PropiedadesFlecha[] objetos = FindObjectsOfType<PropiedadesFlecha>();
        objetosConPosicionOriginal = new ObjetoConPosicionOriginal[objetos.Length];

        for (int i = 0; i < objetos.Length; i++)
        {
            objetosConPosicionOriginal[i].objeto = objetos[i];
            objetosConPosicionOriginal[i].posicionOriginal = objetos[i].transform.position;
        }
    }

    public void DesactivarObjetos()
    {
        foreach (var objetoConPosicion in objetosConPosicionOriginal)
        {
            objetoConPosicion.objeto.gameObject.SetActive(false);
        }
    }

    public void ActivarObjetos()
    {
        foreach (var objetoConPosicion in objetosConPosicionOriginal)
        {
            objetoConPosicion.objeto.gameObject.SetActive(true);
            objetoConPosicion.objeto.transform.position = objetoConPosicion.posicionOriginal; // Restaurar la posición original
        }
    }
}
