Public Class Form1

    'Declaración de variables
    Private mPlatos(,) As String
    Private cantPlatos As String
    Private index As Integer

    Private encuentra As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnVender.Enabled = False
        txtPrecio.Enabled = False
        txtDisponible.Enabled = False

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'Entrada de Datos
        cantPlatos = Val(txtCantPlatos.Text)
        'Inicializar ahora la matriz
        ReDim Preserve mPlatos(cantPlatos, 3)
        'Ingresar datos a nuestra matriz
        For i As Integer = 0 To cantPlatos - 1 Step 1
            mPlatos(i, 0) = InputBox("Ingrese el nombre del plato " & (i + 1), "Restaurant")
            mPlatos(i, 1) = InputBox("Ingrese el precio del plato " & (i + 1), "Restaurant")
            mPlatos(i, 2) = InputBox("Ingrese el stock del plato " & (i + 1), "Restaurant")
        Next
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'Declaración de variables
        Dim plato As String
        'Entrada de datos
        plato = txtPlato.Text
        'Buscamos  si el plato ingresado existe
        For i As Integer = 0 To (cantPlatos - 1) Step 1
            If (mPlatos(i, 0) = plato) Then
                txtPrecio.Text = mPlatos(i, 1)
                txtDisponible.Text = mPlatos(i, 2)
                index = i
                btnVender.Enabled = True
                encuentra = 1
            End If
        Next
        If (encuentra = 0) Then
            MessageBox.Show("No existe el plato", "Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnVender.Enabled = False
        End If

    End Sub

    Private Sub btnVender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVender.Click
        'Declaración de variables
        Dim cant As Integer, stock As Integer
        'Entrada de Datos
        cant = Val(txtCantidad.Text)
        stock = mPlatos(index, 2)
        If (cant <= stock) Then
            'Disminuir el stock de ese plato
            mPlatos(index, 2) = stock - cant
        Else
            MessageBox.Show("NO hay suficiente Stock", "Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
