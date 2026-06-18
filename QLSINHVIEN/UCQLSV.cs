using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSINHVIEN
{
    public partial class UCQLSV : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        private const int SoDongMoiTrang = 10;
        private int trangHienTai = 1;
        private int tongSoDong = 0;
        private int tongSoTrang = 1;
        private int sinhVienDangChonId = 0;

        public UCQLSV()
        {
            InitializeComponent();
            CauHinhDataGridView();
            CauHinhPhanTrang();
            CauHinhUpdate();
            LoadLopHoc();
        }

        private void UCQLSV_Load(object sender, EventArgs e)
        {
            trangHienTai = 1;
            LoadSinhVien();
        }
        private void LoadSinhVien()
        {
            tongSoDong = db.sinhviens.Count();
            tongSoTrang = Math.Max(1, (int)Math.Ceiling((double)tongSoDong / SoDongMoiTrang));
            trangHienTai = Math.Max(1, Math.Min(trangHienTai, tongSoTrang));

            var ds = from sv in db.sinhviens
                     orderby sv.id
                     select new
                     {
                         sv.id,
                         sv.masv,
                         sv.hoten,
                         sv.ngaysinh,
                         sv.gioitinh,
                         sv.malop
                     };

            dataGridView1.DataSource = ds.Skip((trangHienTai - 1) * SoDongMoiTrang)
                                         .Take(SoDongMoiTrang)
                                         .ToList();
            sinhVienDangChonId = 0;
            dataGridView1.ClearSelection();
            CapNhatThongTinPhanTrang();
        }

        private void CauHinhDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CauHinhPhanTrang()
        {
            button6.Click += button6_Click;
            button7.Click += button7_Click;
            button9.Click += button9_Click;
            button8.Click += button8_Click;
        }

        private void CauHinhUpdate()
        {
            btn_edit.Click += btn_edit_Click;
        }

        private void CapNhatThongTinPhanTrang()
        {
            label7.Text = $"Trang {trangHienTai}/{tongSoTrang} | {tongSoDong} bản ghi";
            button6.Enabled = trangHienTai > 1;
            button7.Enabled = trangHienTai > 1;
            button9.Enabled = trangHienTai < tongSoTrang;
            button8.Enabled = trangHienTai < tongSoTrang;
        }

        private void ChuyenTrang(int trangMoi)
        {
            trangMoi = Math.Max(1, Math.Min(trangMoi, tongSoTrang));
            if (trangMoi == trangHienTai)
            {
                return;
            }

            trangHienTai = trangMoi;
            LoadSinhVien();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChuyenTrang(1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChuyenTrang(trangHienTai - 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChuyenTrang(trangHienTai + 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChuyenTrang(tongSoTrang);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            DoThongTinSinhVien(dataGridView1.Rows[e.RowIndex]);
        }

        private void DoThongTinSinhVien(DataGridViewRow row)
        {
            int.TryParse(LayGiaTriCell(row, "id"), out sinhVienDangChonId);
            txt_mssv.Text = LayGiaTriCell(row, "masv");
            txt_name.Text = LayGiaTriCell(row, "hoten");
            box_gioitinh.Text = LayGiaTriCell(row, "gioitinh");

            string ngaySinh = LayGiaTriCell(row, "ngaysinh");
            DateTime ngaySinhValue;
            if (DateTime.TryParse(ngaySinh, out ngaySinhValue))
            {
                date_ngaysinh.Value = ngaySinhValue;
            }

            string maLop = LayGiaTriCell(row, "malop");
            if (!string.IsNullOrWhiteSpace(maLop))
            {
                box_lophoc.SelectedValue = maLop;
            }
        }

        private string LayGiaTriCell(DataGridViewRow row, string columnName)
        {
            if (!dataGridView1.Columns.Contains(columnName))
            {
                return string.Empty;
            }

            object value = row.Cells[columnName].Value;
            return value == null || value == DBNull.Value ? string.Empty : value.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                sinhvien sv = new sinhvien();

                sv.masv = txt_mssv.Text.Trim();
                sv.hoten = txt_name.Text.Trim();
                sv.gioitinh = box_gioitinh.Text;
                sv.ngaysinh = date_ngaysinh.Value;

                sv.malop = box_lophoc.SelectedValue.ToString();

                db.sinhviens.InsertOnSubmit(sv);
                db.SubmitChanges();

                MessageBox.Show("Thêm thành công");
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (sinhVienDangChonId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_mssv.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên");
                    txt_mssv.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_name.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên");
                    txt_name.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(box_gioitinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn giới tính");
                    box_gioitinh.Focus();
                    return;
                }

                if (box_lophoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp");
                    box_lophoc.Focus();
                    return;
                }

                string maSinhVien = txt_mssv.Text.Trim();
                bool trungMa = db.sinhviens.Any(sv => sv.masv == maSinhVien && sv.id != sinhVienDangChonId);
                if (trungMa)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại");
                    txt_mssv.Focus();
                    return;
                }

                sinhvien svCanSua = db.sinhviens.FirstOrDefault(sv => sv.id == sinhVienDangChonId);
                if (svCanSua == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần sửa");
                    LoadSinhVien();
                    return;
                }

                svCanSua.masv = maSinhVien;
                svCanSua.hoten = txt_name.Text.Trim();
                svCanSua.ngaysinh = date_ngaysinh.Value.Date;
                svCanSua.gioitinh = box_gioitinh.Text.Trim();
                svCanSua.malop = box_lophoc.SelectedValue.ToString();

                db.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadLopHoc()
        {
            box_lophoc.DataSource = db.lophocs.ToList();

            box_lophoc.DisplayMember = "tenlop";
            box_lophoc.ValueMember = "malop";
        }
    }
}
