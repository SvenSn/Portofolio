using FitnessProject.Domein.Models;
using System.Collections.ObjectModel;

namespace FitnessProject.Domein.DTOs;

public record LoopTrainingDTO(int sessieNr,DateTime startDatum,int totaleduurMinuten,double gemiddeldeSnelheid);
