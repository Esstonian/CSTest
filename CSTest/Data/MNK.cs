using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSTest.Data {
    public class MNK {
        private double[] result;
        private double[,] xyTable, matrix;

        public double calc(double[] consuption, int basis) {

            xyTable = new double[2, consuption.Length];

            for (int i = 0; i < consuption.Length; i++) {
                xyTable[0, i] = i;
                xyTable[1, i] = consuption[i];
            }

            basis += 1; //степень полинома
            matrix = makeSystem(xyTable, basis, consuption.Length);

            result = gauss(matrix, basis, basis + 1);

            return calcX(consuption.Length - 1, basis - 1);
        }

        private double calcX(int x, int basis) {
            basis += 1;
            double y = 0;
            for (int i = 0; i < basis; i++) {
                y += result[i] * Math.Pow(x, i);
            }
            return y;
        }

        private double[,] makeSystem(double[,] xyTable, int basis, int dataLength) {
            double[,] matrix = new double[basis, basis + 1];

            for (int i = 0; i < basis; i++) {
                for (int j = 0; j < basis; j++) {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < dataLength; k++) {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
                        sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, basis] = sumB;
                }
            }
            return matrix;
        }

        private double[] gauss(double[,] matrix, int rowCount, int colCount) {
            int i;
            int[] mask = new int[colCount - 1];
            for (i = 0; i < colCount - 1; i++) mask[i] = i;
            if (gaussDirectPass(ref matrix, ref mask, colCount, rowCount)) {
                double[] answer = gaussReversePass(ref matrix, mask, colCount, rowCount);
                return answer;
            } else return null;
        }

        private bool gaussDirectPass(ref double[,] matrix, ref int[] mask,
            int colCount, int rowCount) {
            int i, j, k, maxId, tmpInt;
            double maxVal, tempDouble;
            for (i = 0; i < rowCount; i++) {
                maxId = i;
                maxVal = matrix[i, i];
                for (j = i + 1; j < colCount - 1; j++)
                    if (Math.Abs(maxVal) < Math.Abs(matrix[i, j])) {
                        maxVal = matrix[i, j];
                        maxId = j;
                    }
                if (maxVal == 0) return false;
                if (i != maxId) {
                    for (j = 0; j < rowCount; j++) {
                        tempDouble = matrix[j, i];
                        matrix[j, i] = matrix[j, maxId];
                        matrix[j, maxId] = tempDouble;
                    }
                    tmpInt = mask[i];
                    mask[i] = mask[maxId];
                    mask[maxId] = tmpInt;
                }
                for (j = 0; j < colCount; j++) matrix[i, j] /= maxVal;
                for (j = i + 1; j < rowCount; j++) {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            }
            return true;
        }

        private double[] gaussReversePass(ref double[,] matrix, int[] mask, int colCount, int rowCount) {
            int i, j, k;
            for (i = rowCount - 1; i >= 0; i--)
                for (j = i - 1; j >= 0; j--) {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            double[] answer = new double[rowCount];
            for (i = 0; i < rowCount; i++) answer[mask[i]] = matrix[i, colCount - 1];
            return answer;
        }
    }
}
